helpText
	^ '
Wellcome to Celeste  and CelesteAddressBook!
CelesteAddressBook can be used to browse your email addresses, auto collect them and sort by frequency.
You can also filter them, comaining all the function. It is quite fast.

1 Getting Started
Open the addressbook with something like:
	CelesteAddressBook open
Now click on "Collect info" button  for opening your default mail db and searching for emails.
Using the menu of the contact list, you can send individual emails.
Using the find box, you can search in the list for a specific string.
Using the "Filter by Freq" you can reorder the contacts presenting first the most present in
 your emails. Can be slow if a lot of contacts are present.

Note: you can combine "filter by freq" and the search filter, without problems.

Last but not least, you can remove contacts using the menu of the contact list ("remove all showed contacts"/"remove selected contact").


2 Exporting/Importing Addressbook
You can save the emails in a file called defaultAddressBook.ser.
Click in the list-menu and select "Save to disk"
use "Load from disk" for re-loading the saved data. 
Note: 
	a) saved data will *replace* your current addressbook list.
	b) The defaultAddressBook.ser is a serialized file: this format is likely to change in the future.



'