openOn: aCeleste
	celeste _ aCeleste.
	contactList _ Dictionary new.
	selectedContact _ nil.
	mutex _ Semaphore forMutualExclusion.
	sortByFreq _ false.
	self privateOpen.
	[self loadAddressBookAsObjectFromFile: 'defaultAddressBook.ser']
		on: Error
		do: [:err | self alert: 'Cannot load default email addresses...click "Get..." and then save it']