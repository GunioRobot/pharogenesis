initListFrom: selectorCollection highlighting: aClass 
	"Make up the messageList with items from aClass in boldface.  Provide a final filtering in that only selectors whose implementations fall within my limitClass will be shown."

	| defClass item |
	messageList := OrderedCollection new.
	selectorCollection do: 
		[:selector |  defClass _ aClass whichClassIncludesSelector: selector.
		(defClass notNil and: [defClass includesBehavior: self limitClass]) ifTrue:
			[item _ selector, '     (' , defClass name , ')'.
			item _ item asText.
			defClass == aClass ifTrue: [item allBold].
			"(self isThereAnOverrideOf: selector) ifTrue: [item addAttribute: TextEmphasis struckOut]."
			"The above has a germ of a good idea but could be very slow"
			messageList add: item]]