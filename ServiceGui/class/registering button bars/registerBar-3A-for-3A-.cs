registerBar: aBar for: service
	
	self bars removeAllSuchThat: [:a | a value isNil].
	self bars add: (WeakValueAssociation key: service value: aBar).