hUnadjustedScrollRange
"Return the width of the widest item in the list"

	| max right stringW count |

	max _ 0.
	count _ 0.
	scroller submorphsDo: [ :each |
		stringW _ each font widthOfStringOrText: each contents.
		right _ (each toggleRectangle right + stringW + 10).
		max _ max max: right.
		
"NOTE: need to optimize this method by caching list item morph widths (can init that cache most efficiently in the #list: method before the item widths are reset to 9999).  For now, just punt on really long lists"
		((count _ count + 1) > 200) ifTrue:[ ^max * 3].
	].

	^max 
