selectorsToBeIgnored

	| deprecated private special |

	deprecated := #( #<= #>= #> ).
	private := #( #date: #time: #printOn: ).
	special := #( #< #= ).

	^ super selectorsToBeIgnored, deprecated, private, special.