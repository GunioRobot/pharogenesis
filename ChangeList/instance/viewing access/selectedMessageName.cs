selectedMessageName

	^ (changeList at: listIndex) methodSelector

"
change _ changeList at: i.
			((change type = #method and:
				[(class _ change methodClass) notNil]) and:
					[(class includesSelector: change methodSelector
"