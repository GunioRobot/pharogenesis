messageTally
	| secString secs |
	secString _ FillInTheBlank request: 'Profile for how many seconds?' initialAnswer: '4'.
	secs _ secString asNumber asInteger.
	(secs isNil
			or: [secs isZero])
		ifTrue: [^ self].
	[ TimeProfileBrowser spyOnProcess: selectedProcess forMilliseconds: secs * 1000 ] forkAt: selectedProcess priority + 1.