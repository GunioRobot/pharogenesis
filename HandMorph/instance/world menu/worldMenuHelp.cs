worldMenuHelp
	| aList aMenu cnts explanation |
	"self currentWorld primaryHand worldMenuHelp"

	aList _ OrderedCollection new.
	#(helpMenu changesMenu openMenu debugMenu projectMenu scriptingMenu windowsMenu playfieldMenu appearanceMenu) 
		with:
	#('help' 'changes' 'open' 'debug' 'projects' 'authoring tools' 'windows & flaps' 'playfield options' 'appearance') do:
		[:sel :title | aMenu _ self perform: sel.
			aMenu items do:
				[:it | (((cnts _ it contents) = 'keep this menu up') or: [cnts size = 0])
					ifFalse: [aList add: (cnts, ' - ', title)]]].
	aList _ aList asSortedCollection: [:a :b | a asLowercase < b asLowercase].

	explanation _ String streamContents: [:aStream | aList do:
		[:anItem | aStream nextPutAll: anItem; cr]].

	(StringHolder new contents: explanation)
		openLabel: 'Where in the world menu is...'