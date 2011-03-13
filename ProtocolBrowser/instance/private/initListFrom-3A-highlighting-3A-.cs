initListFrom: selectorCollection highlighting: aClass 
	"Make up the messageList with items from aClass in boldface."
	| defClass item |

	messageList := OrderedCollection new.
	selectorCollection do: [ :selector |  
		defClass := aClass whichClassIncludesSelector: selector.
		item := selector, '     (' , defClass name , ')'.
		defClass == aClass ifTrue: [item := item asText allBold].
		messageList add: (
			MethodReference new
				setClass: defClass 
				methodSymbol: selector 
				stringVersion: item
		)
	].
	selectedClass := aClass.