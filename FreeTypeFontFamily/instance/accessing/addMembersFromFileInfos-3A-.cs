addMembersFromFileInfos: aCollectionOfFreeTypeFileInfo
	
	| member |
	aCollectionOfFreeTypeFileInfo do:[:aFileInfo |
		member := FreeTypeFontFamilyMember fromFileInfo: aFileInfo.
		(self memberWithStyleName: member styleName)
			ifNil:[self addMember: member]].
	