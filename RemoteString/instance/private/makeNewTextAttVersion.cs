makeNewTextAttVersion
	"Create a new TextAttributes version because some inst var has changed.  If no change, don't make a new one."
	"Don't delete this method even though it has no callers!!!!!"

| obj cls struct tag |
"Note that TextFontReference and TextAnchor are forbidden."
obj _ #(RunArray TextDoIt TextLink TextURL TextColor TextEmphasis TextFontChange TextKern TextLinkToImplementors 3 'a string') collect: [:each | 
		cls _ Smalltalk at: each ifAbsent: [nil].
		cls ifNil: [each] ifNotNil: [cls new]].
struct _ (SmartRefStream on: (RWBinaryOrTextStream on: String new)) instVarInfo: obj.
tag _ self checkSum: struct printString.
TextAttributeStructureVersions ifNil: [TextAttributeStructureVersions _ Dictionary new].
(struct = CurrentTextAttStructure) & (tag = CurrentTextAttVersion) 
	ifTrue: [^ false].
CurrentTextAttStructure _ struct.
CurrentTextAttVersion _ tag.
TextAttributeStructureVersions at: tag put: struct.
^ true