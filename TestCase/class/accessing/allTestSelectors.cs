allTestSelectors

	^self sunitAllSelectors select: [:each | 'test*' sunitMatch: each]
			