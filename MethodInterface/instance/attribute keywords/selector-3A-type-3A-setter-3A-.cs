selector: aSelector type: aType setter: aSetter
	"Set the receiver's fields as indicated.  Values of nil or #none for the result type and the setter indicate that there is none"

	selector _ aSelector.
	(MethodInterface isNullMarker: aType) ifFalse:
		[resultSpecification _ ResultSpecification new.
		resultSpecification resultType: aType.
		(MethodInterface isNullMarker: aSetter) ifFalse:
			[resultSpecification companionSetterSelector: aSetter]]