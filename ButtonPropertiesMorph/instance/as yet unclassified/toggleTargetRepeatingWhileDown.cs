toggleTargetRepeatingWhileDown

	| prop |

	prop _ self targetProperties.
	prop delayBetweenFirings: (prop delayBetweenFirings ifNil: [1024] ifNotNil: [nil])
	