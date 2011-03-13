selectorsSendingSelectedSelector
	"Assumes lastSendersSearchSelector is already set"
	| selectorSet sel cl |
	autoSelectString := (self lastSendersSearchSelector upTo: $:) asString.
	selectorSet := Set new.
	(self systemNavigation allCallsOn: self lastSendersSearchSelector)
		do: [:anItem | 
			sel := anItem methodSymbol.
			cl := anItem actualClass.
			((currentVocabulary
						includesSelector: sel
						forInstance: self targetObject
						ofClass: targetClass
						limitClass: limitClass)
					and: [targetClass includesBehavior: cl])
				ifTrue: [selectorSet add: sel]].
	^ selectorSet asSortedArray