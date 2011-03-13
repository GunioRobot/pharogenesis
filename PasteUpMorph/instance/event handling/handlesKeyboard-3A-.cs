handlesKeyboard: evt
	^self isWorldMorph or:[evt keyCharacter == Character tab and:[self hasProperty: #tabAmongFields]]