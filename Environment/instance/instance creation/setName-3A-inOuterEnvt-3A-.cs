setName: name inOuterEnvt: outer
	outerEnvt _ outer.
	envtName _ name asSymbol.
	outerEnvt ifNotNil:
		[outerEnvt at: envtName put: self].  "install me in parent by name"
