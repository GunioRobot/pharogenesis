replaceSel: evt menuItem: stringMorph
	"I rep a SelectorNode.  Replace my selector with new one that was just chosen from a menu"

	| menu new old newSel ms oa na case news |
	(menu _ stringMorph owner owner) class == RectangleMorph ifTrue: [
		menu delete].
	new _ stringMorph contents.
	new first = $( ifTrue: [^ self].	"Cancel"
	new first = $  ifTrue: [^ self].	"nothing"
	news _ String streamContents: [:strm | "remove fake args"
		(new findBetweenSubStrs: #(' 5' $ )) do: [:part | strm nextPutAll: part]].
	newSel _ stringMorph valueOfProperty: #syntacticallyCorrectContents.
	newSel ifNil: [newSel _ news].
	old _ (ms _ self findA: StringMorph) valueOfProperty: #syntacticallyCorrectContents.
	old ifNil: [old _ (self findA: StringMorph) contents].
	oa _ old numArgs.  na _ newSel numArgs.  case _ 5.
	(oa = 1) & (na = 1) ifTrue: [case _ 1]. 
	(oa = 0) & (na = 0) ifTrue: [case _ 2].
	(oa = 1) & (na  = 0) ifTrue: [case _ 3].
	(oa = 0) & (na  = 1) ifTrue: [case _ 4].
	case <= 4 ifTrue: ["replace the selector"
		ms contents: news.	"not multi-part"
		ms setProperty: #syntacticallyCorrectContents toValue: newSel].
	case = 3 ifTrue: [owner tossOutArg: 1].
	case = 4 ifTrue: [self addArg: 1].
	"more cases here.  Rebuild the entire MessageNode"
	
	self acceptIfInScriptor.