makeRandomString

	| newString foo |

	newString _ String new: Goal contents size.
	foo _ Goal contents size.
	^newString collect: [ :oldLetter | 'abcdefghijklmnopqrstuvwxyz' atRandom]
