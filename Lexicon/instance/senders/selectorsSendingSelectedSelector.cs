selectorsSendingSelectedSelector
	"Assumes lastSendersSearchSelector is already set"
	| selectorSet sel cl |
	autoSelectString _ (self lastSendersSearchSelector upTo: $:) asString.
	selectorSet _ Set new.
	(self systemNavigation allCallsOn: self lastSendersSearchSelector)
		do: [:anItem | 
			sel _ anItem methodSymbol.
			cl _ anItem actualClass.
			((currentVocabulary
						includesSelector: sel
						forInstance: self targetObject
						ofClass: targetClass
						limitClass: limitClass)
					and: [targetClass includesBehavior: cl])
				ifTrue: [selectorSet add: sel]].
	^ selectorSet asSortedArray