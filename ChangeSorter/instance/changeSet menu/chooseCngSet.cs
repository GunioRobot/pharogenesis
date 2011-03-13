chooseCngSet
	"Present the user with an alphabetical list of change set names, and let her choose one"

	| changeSetsSortedAlphabetically chosen |
	self okToChange ifFalse: [^ self].

	changeSetsSortedAlphabetically := self changeSetList asSortedCollection:
		[:a :b | a asLowercase withoutLeadingDigits < b asLowercase withoutLeadingDigits].

	chosen := (SelectionMenu selections: changeSetsSortedAlphabetically)
			startUp.
	chosen ifNil: [^ self].
	self showChangeSet: (ChangeSorter changeSetNamed: chosen)