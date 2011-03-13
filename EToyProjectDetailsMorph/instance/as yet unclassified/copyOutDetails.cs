copyOutDetails

	| newDetails |

	newDetails _ Dictionary new.
	self fieldToDetailsMappings do: [ :each |
		namedFields at: each first ifPresent: [ :field |
			newDetails at: each second put: field contents string
		].
	].
	namedFields at: 'projectname' ifPresent: [ :field |
		newDetails at: 'projectname' put: field contents string
	].
	^newDetails