hUnadjustedScrollRange
"Ok, this is a bit messed up. We need to return the width of the widest item in the list. If we grab every item in the list, it defeats the purpose of LazyListMorph. If we don't, then we don't know the size. This is a compromise -- if the list is less then 30 items, we grab them all. If not, we grab currently visible ones, until we've checked itemsToCheck of them, then take the max width out of that 'sampling', then double it. If you know a better way, please chime in."

	| maxW count itemsToCheck item |

	itemsToCheck _ 30.
	maxW _ 0. 
	count _ 0.
	listItems do: 
		[ :each |
			each ifNotNil: 
				[maxW _ maxW max: (self widthToDisplayItem: each contents)]].
				
	(count < itemsToCheck) ifTrue:
		[1 to: listItems size do: 
			[:i | (listItems at: i) ifNil: 
							[item _ self item: i.
							maxW _ maxW max: (self widthToDisplayItem: item contents).
							((count _ count + 1) > itemsToCheck) ifTrue:[ ^maxW * 2]]]].
	
	^maxW 
