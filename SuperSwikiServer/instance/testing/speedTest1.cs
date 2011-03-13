speedTest1

"SuperSwikiServer testOnlySuperSwiki speedTest1"

	| answer t totalTime |

	totalTime _ [
		answer _ (1 to: 10) collect: [ :x |
			t _ [answer _ self sendToSwikiProjectServer: {
				'action: readnamedfile'.
				'projectname: xyz.002.pr'.
			}] timeToRun.
			{t. answer size}
		].
	] timeToRun.
	^{totalTime. answer}
