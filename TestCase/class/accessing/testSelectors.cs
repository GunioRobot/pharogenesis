testSelectors

	^self sunitSelectors select: [:each | 'test*' sunitMatch: each]
			