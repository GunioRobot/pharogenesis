reportPlayersAndScripts
	"Open a window which contains a report on players and their scripts"

	| aList aString |
	(aList _ self uniclassesAndCounts) size == 0 ifTrue: [^ self inform: 'there are no scripted players'].
	aString _ String streamContents:
		[:aStream |
			aList do:
				[:aPair | aStream nextPutAll: aPair first name, ' -- ', aPair second printString, ' instance',
		(aPair second > 1 ifTrue: ['s'] ifFalse: ['']) , ', named '.
					aPair first allInstancesDo: [:inst | aStream space; nextPutAll: inst externalName].
					aStream cr].
			aStream cr.
			aList do:
				[:aPair |
					aStream cr.
					aStream nextPutAll: 
'--------------------------------------------------------------------------------------------'.
					aStream cr; nextPutAll: aPair first name.
					aPair first addDocumentationForScriptsTo: aStream]].

	(StringHolder new contents: aString)
		openLabel: 'All scripts of all players in this world'

"self currentWorld presenter reportPlayersAndScripts"