allWordingsNotInSubMenu: verbotenSubmenuContents
	"Answer a collection of the wordings of all items and subitems, but omit the stay-up item, and also any items in a submenu whose tag is given by verbotenSubmenuContents"
	self isStayUpItem ifTrue:[^#()].
	subMenu ifNotNil:[^subMenu allWordingsNotInSubMenu: verbotenSubmenuContents].
	self contents asString = verbotenSubmenuContents ifTrue:[^#()].
	^Array with: self contents asString