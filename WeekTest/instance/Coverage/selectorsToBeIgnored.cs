selectorsToBeIgnored

	| deprecated private special |

	deprecated := #( #startMonday #toggleStartMonday).
	private := #( #indexInMonth: #printOn: ).
	special := #( #next #do: ).

	^ super selectorsToBeIgnored, deprecated, private, special.