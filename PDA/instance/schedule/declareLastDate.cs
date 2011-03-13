declareLastDate
	(self confirm: 'Please confirm termination of this event as of
' , date printString , '.')
		ifFalse: [^ self].
	currentItem lastDate: date.
	self currentItem: currentItem
