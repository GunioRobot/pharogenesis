example
	"PluggableButtonView example"

	| s1 s2 s3 b1 b2 b3 topView |
	s1 := Switch new.
	s2 := Switch new turnOn.
	s3 := Switch new.
	s2 onAction: [s3 turnOff].
	s3 onAction: [s2 turnOff].
	b1 := (PluggableButtonView on: s1 getState: #isOn action: #switch) label: 'S1'.
	b2 := (PluggableButtonView on: s2 getState: #isOn action: #turnOn) label: 'S2'.
	b3 := (PluggableButtonView on: s3 getState: #isOn action: #turnOn) label: 'S3'.
	b1 borderWidth: 1.
	b2 borderWidth: 1.
	b3 borderWidth: 1.
	topView := StandardSystemView new
		label: 'Switch Test';
		addSubView: b1;
		addSubView: b2 toRightOf: b1;
		addSubView: b3 toRightOf: b2.
	topView controller open.
