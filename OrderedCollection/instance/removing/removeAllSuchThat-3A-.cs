removeAllSuchThat: aBlock 
	"Remove each element of the receiver for which aBlock evaluates to true.
	The method in Collection is O(N^2), this is O(N)."

	| n |
	n _ firstIndex.
	firstIndex to: lastIndex do: [:index |
	    (aBlock value: (array at: index)) ifFalse: [
			array at: n put: (array at: index).
			n _ n + 1]].
	n to: lastIndex do: [:index | array at: index put: nil].
	lastIndex _ n - 1