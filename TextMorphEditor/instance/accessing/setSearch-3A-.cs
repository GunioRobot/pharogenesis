setSearch: aString
	| bk |
	"Set the FindText and ChangeText to seek aString; except if already seeking aString, leave ChangeText alone so again will repeat last replacement."

	(bk _ morph ownerThatIsA: BookMorph) ifNotNil: [
		bk setProperty: #tempSearchKey 
			toValue: (aString findTokens: Character separators)].


	FindText string = aString
		ifFalse: [FindText _ ChangeText _ aString asText]