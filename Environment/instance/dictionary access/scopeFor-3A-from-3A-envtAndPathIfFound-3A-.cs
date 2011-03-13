scopeFor: varName from: prior envtAndPathIfFound: envtAndPathBlock
	"Look up varName here or in any sub-environments, and also in any sub-environments of the outer environment.  If found, evaluate pathBlock with a string giving the path for the access, and return the environment in which the variable was found.  Return nil if the variable is not found.

	Call from outside with prior == nil.
	prior ~= nil prevents revisiting prior parts of the tree."

	| envt |
	"Might be right here -- null path."
	(self includesKey: varName) ifTrue:
		[^ envtAndPathBlock value: self value: String new].

	"Might be in a sub-environment -- append envt name to downward path."
	self associationsDo:
		[:assn |
		(((envt _ assn value) isKindOf: Environment)
			and: [envt ~~ self and: [envt ~~ prior]]) ifTrue:
				[envt scopeFor: varName from: self envtAndPathIfFound:
						[:subEnvt :subPath |
						^ envtAndPathBlock value: subEnvt value: assn key , ' ' , subPath]]].

	"If not found, traverse outer environment."
	outerEnvt ifNil: [^ nil].
	outerEnvt == prior ifTrue: [^ nil].
	outerEnvt scopeFor: varName from: self envtAndPathIfFound:
						[:subEnvt :subPath |
						^ envtAndPathBlock value: subEnvt value: subPath].
