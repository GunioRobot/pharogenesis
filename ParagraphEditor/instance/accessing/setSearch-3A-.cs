setSearch: aString
	"Set the FindText and ChangeText to seek aString; except if already seeking aString, leave ChangeText alone so again will repeat last replacement."

	FindText string = aString
		ifFalse: [FindText _ ChangeText _ aString asText]