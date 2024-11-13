import {
    Outlet,
    Link,
    useLoaderData,
    Form,
} from "react-router-dom";
import { useState } from "react"; // Import useState
import { getContacts, createContact } from "../contacts";
import { redirect } from "react-router-dom";

// Action to create a new contact
export async function action({ request }) {
    const formData = new URLSearchParams(await request.text());
    const first = formData.get("first");
    const last = formData.get("last");

    const contact = await createContact({ first, last }); // Pass details to createContact
    return redirect(`/contacts/${contact.id}`); // Redirect to the newly created contact's detail page
}

// Loader function to fetch contacts
export async function loader() {
    const contacts = await getContacts();
    return { contacts };
}

// Main Root component
export default function Root() {
    const { contacts } = useLoaderData();
    const [showNewContactForm, setShowNewContactForm] = useState(false); // State to manage form visibility

    const toggleNewContactForm = () => {
        setShowNewContactForm(prev => !prev); // Toggle form visibility
    };

    return (
        <>
            <div id="sidebar">
                <h1>React Router Contacts</h1>
                <div>
                    <form id="search-form" role="search">
                        <input
                            id="q"
                            aria-label="Search contacts"
                            placeholder="Search"
                            type="search"
                            name="q"
                        />
                        <div id="search-spinner" aria-hidden hidden={true} />
                        <div className="sr-only" aria-live="polite"></div>
                    </form>
                    {/* Button to toggle new contact form */}
                    <button onClick={toggleNewContactForm}>
                        {showNewContactForm ? "Cancel" : "New"}
                    </button>

                    {/* Conditionally render the new contact form */}
                    {showNewContactForm && (
                        <Form method="post" action="/contacts/new">
                            <label>
                                First Name:
                                <input type="text" name="first" required />
                            </label>
                            <label>
                                Last Name:
                                <input type="text" name="last" required />
                            </label>
                            <button type="submit">Create</button>
                        </Form>
                    )}
                </div>
                <nav>
                    {contacts.length ? (
                        <ul>
                            {contacts.map((contact) => (
                                <li key={contact.id}>
                                    <Link to={`contacts/${contact.id}`}>
                                        {contact.first || contact.last ? (
                                            <>
                                                {contact.first} {contact.last}
                                            </>
                                        ) : (
                                            <i>No Name</i>
                                        )}
                                    </Link>
                                </li>
                            ))}
                        </ul>
                    ) : (
                        <p><i>No contacts</i></p>
                    )}
                </nav>
            </div>
            <div id="detail">
                {/* This is where we can render other components or outlets if needed */}
                <Outlet />
            </div>
        </>
    );
}