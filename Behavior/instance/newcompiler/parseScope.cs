parseScope

	^ Smalltalk at: #ClassScope ifPresent: [:class | class new class: self]