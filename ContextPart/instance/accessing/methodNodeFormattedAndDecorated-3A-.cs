methodNodeFormattedAndDecorated: decorate
	"Answer a method node made from pretty-printed (and colorized, if decorate is true) source text."

	| selector methodClass |
	selector _ self receiver class
		selectorAtMethod: self method
		setClass: [:mclass | methodClass _ mclass].
	^ self method methodNodeFormattedDecompileClass: methodClass selector: selector decorate: decorate