contents

	^item children collect: [ :each | 
		EToyTextNodeWrapper with: each model: model parent: self
	].
