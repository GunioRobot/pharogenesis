initListFrom: selectorCollection highlighting: aClass 
	"Make up the messageList with items from aClass in boldface."
	| defClass item |
	messageList := OrderedCollection new.
	selectorCollection do: 
		[:selector |  defClass := aClass whichClassIncludesSelector: selector.
		item _ selector, '     (' , defClass name , ')'.
		messageList add: (defClass == aClass ifTrue:[item asText allBold] ifFalse:[item])]