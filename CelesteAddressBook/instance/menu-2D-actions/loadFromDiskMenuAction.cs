loadFromDiskMenuAction
	[self loadAddressBookAsObjectFromFile: 'defaultAddressBook.ser'.
	self alert: 'Loaded from disk: ' , contactList size asString , ' contatcts']
		on: Error
		do: [:err | 
			self alert: 'Error loading:' , err messageText, ' Do you have the defaultAddressBook.ser?'.
			"If you like: err defaultAction"]