addRemoteTemp: aTempVariableNode rootNode: rootNode "<MethodNode>"
	"Add aTempVariableNode to my actualScope's sequence of
	 remote temps.  If I am an optimized block then the actual
	 scope is my actualScopeIfOptimized, otherwise it is myself."
	temporaries isArray ifTrue:
		[temporaries := temporaries asOrderedCollection].
	remoteTempNode == nil ifTrue:
		[remoteTempNode := RemoteTempVectorNode new
								name: self remoteTempNodeName
								index: arguments size + temporaries size
								type: LdTempType
								scope: 0.
		 actualScopeIfOptimized
			ifNil:
				[temporaries addLast: remoteTempNode.
				 remoteTempNode definingScope: self]
			ifNotNil: [actualScopeIfOptimized addHoistedTemps: { remoteTempNode }]].
	remoteTempNode addRemoteTemp: aTempVariableNode encoder: rootNode encoder.
	"use remove:ifAbsent: because the deferred analysis for optimized
	 loops can result in the temp has already been hoised into the root."
	temporaries remove: aTempVariableNode ifAbsent: [].
	^remoteTempNode