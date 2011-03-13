asCharacter
	"Answer the receiver's first character, or a * if none.  Idiosyncratic, provisional."

	self deprecated: 'Don''t use it, it''s evil.'.
	^ self size > 0 ifTrue: [self first] ifFalse:[$*]