updatesSinceFirstTransaction
	"Produce a String with all recorded transactions from the logfile.
	We go to the beginning of the file,
	then we search for the text 'firstTransactionNumber: xxx'.
	Finally we return all transactions from then on.
	The implementation uses the new method #findString: which
	should be reasonably fast."

	| file found result key |
	[ file _ self openLogFileReadOnly.
	key _ 'self firstTransactionNumber:'.
	found _ file findString: key.
	found = 0
		ifTrue:[result _ nil]
		ifFalse: [
			file skip: key size; upTo: $!; next.
			result _ file upToEnd ]]
				ensure: [file close].
	^result
