openMessageBrowserForClass: aBehavior selector: aSymbol editString: aString
	"Create and schedule a message browser for the class, aBehavior, in 
	which the argument, aString, contains characters to be edited in the text 
	view. These characters are the source code for the message selector 
	aSymbol."

	| newBrowser aClass systemCatIndex messageCatIndex isMeta |
	newBrowser _ Browser new.
	(aBehavior isKindOf: Metaclass)
		ifTrue: [isMeta _ true. aClass _ aBehavior soleInstance]
		ifFalse: [isMeta _ false. aClass _ aBehavior].
	systemCatIndex _ SystemOrganization categories indexOf: aClass category.
	newBrowser systemCategoryListIndex: systemCatIndex.
	newBrowser classListIndex:
			((SystemOrganization listAtCategoryNumber: systemCatIndex)
					indexOf: aClass name).
	newBrowser metaClassIndicated: isMeta.
	messageCatIndex _ aBehavior organization numberOfCategoryOfElement: aSymbol.
	newBrowser messageCategoryListIndex: messageCatIndex.
	newBrowser messageListIndex:
			((aBehavior organization listAtCategoryNumber: messageCatIndex)
					indexOf: aSymbol).
	^self openMessageBrowser: newBrowser editString: aString