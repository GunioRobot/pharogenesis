browseCurrentVersionsOfSelections
	"Opens a message-list browser on the current in-memory versions of all methods that are currently seleted"
	|  aClass aChange aList |

	aList _ OrderedCollection new.
	Cursor read showWhile: [
		1 to: changeList size do: [:i |
			(listSelections at: i) ifTrue: [
				aChange _ changeList at: i.
				(aChange type = #method
					and: [(aClass _ aChange methodClass) notNil
					and: [aClass includesSelector: aChange methodSelector]])
						ifTrue: [
							aList add: (
								MethodReference new
									setStandardClass: aClass  
									methodSymbol: aChange methodSelector
							)
						]]]].

	aList size == 0 ifTrue: [^ self inform: 'no selected methods have in-memory counterparts'].
	MessageSet 
		openMessageList: aList 
		name: 'Current versions of selected methods in ', file localName