lastTransactionInLog
	"Find the last transaction number in the current logfile."

	| file |
	[ file _ self openLogFileReadOnly setToEnd.
	#('self transactionCounter:' 'self firstTransactionNumber:')
		do: [:key |
			(file findStringFromEnd: key) = 0
				ifFalse: [
					file skip: key size.
					^(file upTo: $!) withBlanksTrimmed asNumber ]]
	] ensure: [file close].
	^0 "No marker found"
