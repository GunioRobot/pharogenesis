worldMenuHelp
	| aList aMenu cnts explanation |
	"self currentWorld primaryHand worldMenuHelp"

	aList _ OrderedCollection new.
	#(helpMenu changesMenu openMenu debugMenu projectMenu scriptingMenu windowsMenu playfieldMenu appearanceMenu flapsMenu) 
		with:
	#('help' 'changes' 'open' 'debug' 'projects' 'authoring tools' 'windows' 'playfield options' 'appearance' 'flaps') do:
		[:sel :title | aMenu _ self perform: sel.
			aMenu items do:
				[:it | (((cnts _ it contents) = 'keep this menu up') or: [cnts isEmpty])
					ifFalse: [aList add: (cnts, ' - ', title translated)]]].
	aList _ aList asSortedCollection: [:a :b | a asLowercase < b asLowercase].

	explanation _ String streamContents: [:aStream | aList do:
		[:anItem | aStream nextPutAll: anItem; cr]].

	(StringHolder new contents: explanation)
		openLabel: 'Where in the world menu is...' translated