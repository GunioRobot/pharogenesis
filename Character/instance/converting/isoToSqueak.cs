isoToSqueak
	"Convert receiver from iso8895-1 (actually CP1252) to mac encoding.
	Does not do lf/cr conversion! Characters not available in MacRoman
	encoding have been remapped to their base characters or to $?."

	value < 128 ifTrue: [^ self].
	^ Character value: (#(
		219 63 226 196 227 201 160 224 246 228 83 220 206 63 90 63		"80-8F"
		63 212 213 210 211 165 208 209 247 170 115 221 207 63 122 217		"90-9F"
		202 193 162 163 63 180 124 164 172 169 187 199 194 45 168 248	 	"A0-AF"
		161 177 50 51 171 181 166 225 252 49 188 200 63 63 63 192 			"B0-BF"
		203 231 229 204 128 129 174 130 233 131 230 232 237 234 235 236 	"C0-CF"
		63 132 241 238 239 205 133 42 175 244 242 243 134 89 63 167	 	"D0-DF"
		136 135 137 139 138 140 190 141 143 142 144 145 147 146 148 149		"E0-EF"
		63 150 152 151 153 155 154 214 191 157 156 158 159 121 63 216		"F0-FF"
	) at: value - 127)