fullPathFor: path
	^path isEmpty ifTrue:[pathName asSqueakPathName] ifFalse:[path]