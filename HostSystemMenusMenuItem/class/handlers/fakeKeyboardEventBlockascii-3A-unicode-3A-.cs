fakeKeyboardEventBlockascii: anAsciiValue unicode: aUnicodeValue
	^[:evt | HostSystemMenusMenuItem fakeKeyboardEventBlockasciiActual: anAsciiValue unicode: aUnicodeValue event: evt]