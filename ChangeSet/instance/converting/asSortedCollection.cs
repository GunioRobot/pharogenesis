asSortedCollection
	"Answer a SortedCollection whose elements are the elements of the 
	receiver. The sort order is the default less than or equal ordering."
	| result |
	result _ SortedCollection new.
	classChanges associationsDo: 
		[:clAssoc | 
		clAssoc value do: 
			[:changeType | result add: clAssoc key, ' - ', changeType]].
	methodChanges associationsDo: 
		[:clAssoc | 
		clAssoc value associationsDo: 
			[:mAssoc | result add: clAssoc key, ' ', mAssoc key, ' - ', mAssoc value]].
	classRemoves do:
		[:cName | result add: cName  , ' - ', 'remove'].
	^ result