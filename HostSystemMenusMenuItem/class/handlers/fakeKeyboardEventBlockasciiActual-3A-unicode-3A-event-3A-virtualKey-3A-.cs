fakeKeyboardEventBlockasciiActual: anAsciiValue unicode: aUnicodeValue event: evt virtualKey: aVirtualKeyValue
	|event |
	
		event := Array new: 8.
		event at: 1 put: 2 "EventTypeKeyboard";
		  at: 2 put: Time millisecondClockValue; 
		  at: 3 put: aVirtualKeyValue asInteger;  
		  at: 4 put: 1; "key down"
		  at: 5 put: 8; "modifier keys  (CmmandKeyBit)"
		  at: 8 put: (evt at: 8).
		Sensor handleEvent: event.
		
		event := Array new: 8.
		event at: 1 put: 2 "EventTypeKeyboard";
		  at: 2 put: Time millisecondClockValue;
		  at: 3 put: anAsciiValue asInteger;
		  at: 4 put: 0; "key char"
		  at: 5 put: 8; "modifier keys  (CmmandKeyBit)"
		  at: 6 put: aUnicodeValue asInteger; "virtual key code"
		  at: 8 put: (evt at: 8).
		Sensor handleEvent: event.

		event := Array new: 8.
		event at: 1 put: 2 "EventTypeKeyboard";
		  at: 2 put: Time millisecondClockValue;
		  at: 3 put: aVirtualKeyValue asInteger;
		  at: 4 put: 2; "key press/release"
		  at: 5 put: 64; "modifier keys  (CmmandKeyBit)"
		  at: 8 put: (evt at: 8).
		Sensor handleEvent: event