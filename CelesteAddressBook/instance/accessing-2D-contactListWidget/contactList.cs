contactList
	"Used by the contactListWidget"
	| ret |
	ret _ self filterContactListFromSearchString.
	sortByFreq
		ifTrue: [
			| oc | 
			"Order by freq:"
			oc _ SortedCollection new.
			oc
				sortBlock: [:x :y | (contactList at: x) frequency > (contactList at: y) frequency].
			oc addAll: ret keys.
			^ oc.]
		ifFalse: [^ret keys asSortedCollection]