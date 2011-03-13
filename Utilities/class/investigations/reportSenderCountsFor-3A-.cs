reportSenderCountsFor: selectorList
	"Produce a report on the number of senders of each of the selectors in the list.  1/27/96 sw"

	| total report thisSize |
	total _ 0.
	report _ '
'.
	selectorList do:
		[:selector | thisSize _ (Smalltalk allCallsOn: selector) size.
		report _ report, thisSize printString, Character tab, selector printString, Character cr.
		total _ total + thisSize].
	report _ report, '--- ------------------
'.
	report _ report, total printString, Character tab, 'TOTAL
'.
	^ report