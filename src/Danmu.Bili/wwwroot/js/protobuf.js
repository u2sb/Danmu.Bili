var commonjsGlobal="undefined"!=typeof globalThis?globalThis:"undefined"!=typeof window?window:"undefined"!=typeof global?global:"undefined"!=typeof self?self:{},protobuf_min$1={exports:{}};(function(module){!function(d){var r,u,n;r={1:[function(t,r,e){r.exports=function(t,r){for(var e=Array(arguments.length-1),n=0,i=2,o=!0;i<arguments.length;)e[n++]=arguments[i++];return new Promise((function(i,s){e[n]=function(t){if(o)if(o=!1,t)s(t);else{for(var r=Array(arguments.length-1),e=0;e<r.length;)r[e++]=arguments[e];i.apply(null,r)}};try{t.apply(r||null,e)}catch(t){o&&(o=!1,s(t))}}))}},{}],2:[function(t,r,e){e.length=function(t){var r=t.length;if(!r)return 0;for(var e=0;1<--r%4&&"="==(t[0|r]||"");)++e;return Math.ceil(3*t.length)/4-e};for(var n=Array(64),i=Array(123),o=0;o<64;)i[n[o]=o<26?o+65:o<52?o+71:o<62?o-4:o-59|43]=o++;e.encode=function(t,r,e){for(var i,o=null,s=[],u=0,f=0;r<e;){var h=t[r++];switch(f){case 0:s[u++]=n[h>>2],i=(3&h)<<4,f=1;break;case 1:s[u++]=n[i|h>>4],i=(15&h)<<2,f=2;break;case 2:s[u++]=n[i|h>>6],s[u++]=n[63&h],f=0}8191<u&&((o=o||[]).push(String.fromCharCode.apply(String,s)),u=0)}return f&&(s[u++]=n[i],s[u++]=61,1===f&&(s[u++]=61)),o?(u&&o.push(String.fromCharCode.apply(String,s.slice(0,u))),o.join("")):String.fromCharCode.apply(String,s.slice(0,u))};var s="invalid encoding";e.decode=function(t,r,e){for(var n,o=e,u=0,f=0;f<t.length;){var h=t.charCodeAt(f++);if(61==h&&1<u)break;if((h=i[h])===d)throw Error(s);switch(u){case 0:n=h,u=1;break;case 1:r[e++]=n<<2|(48&h)>>4,n=h,u=2;break;case 2:r[e++]=(15&n)<<4|(60&h)>>2,n=h,u=3;break;case 3:r[e++]=(3&n)<<6|h,u=0}}if(1===u)throw Error(s);return e-o},e.test=function(t){return/^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$/.test(t)}},{}],3:[function(t,r,e){function n(){this.t={}}(r.exports=n).prototype.on=function(t,r,e){return(this.t[t]||(this.t[t]=[])).push({fn:r,ctx:e||this}),this},n.prototype.off=function(t,r){if(t===d)this.t={};else if(r===d)this.t[t]=[];else for(var e=this.t[t],n=0;n<e.length;)e[n].fn===r?e.splice(n,1):++n;return this},n.prototype.emit=function(t){var r=this.t[t];if(r){for(var e=[],n=1;n<arguments.length;)e.push(arguments[n++]);for(n=0;n<r.length;)r[n].fn.apply(r[n++].ctx,e)}return this}},{}],4:[function(t,r,e){function n(t){function r(t,r,e,n){var i=r<0?1:0;t(0===(r=i?-r:r)?0<1/r?0:2147483648:isNaN(r)?2143289344:34028234663852886e22<r?(i<<31|2139095040)>>>0:r<11754943508222875e-54?(i<<31|Math.round(r/1401298464324817e-60))>>>0:(i<<31|127+(t=Math.floor(Math.log(r)/Math.LN2))<<23|8388607&Math.round(r*Math.pow(2,-t)*8388608))>>>0,e,n)}function e(t,r,e){return r=2*((t=t(r,e))>>31)+1,e=t>>>23&255,t&=8388607,255==e?t?NaN:1/0*r:0==e?1401298464324817e-60*r*t:r*Math.pow(2,e-150)*(8388608+t)}function n(t,r,e){a[0]=t,r[e]=c[0],r[e+1]=c[1],r[e+2]=c[2],r[e+3]=c[3]}function f(t,r,e){a[0]=t,r[e]=c[3],r[e+1]=c[2],r[e+2]=c[1],r[e+3]=c[0]}function h(t,r){return c[0]=t[r],c[1]=t[r+1],c[2]=t[r+2],c[3]=t[r+3],a[0]}function l(t,r){return c[3]=t[r],c[2]=t[r+1],c[1]=t[r+2],c[0]=t[r+3],a[0]}var a,c,p,y,d;function b(t,r,e,n,i,o){var s,u=n<0?1:0;0===(n=u?-n:n)?(t(0,i,o+r),t(0<1/n?0:2147483648,i,o+e)):isNaN(n)?(t(0,i,o+r),t(2146959360,i,o+e)):17976931348623157e292<n?(t(0,i,o+r),t((u<<31|2146435072)>>>0,i,o+e)):n<22250738585072014e-324?(t((s=n/5e-324)>>>0,i,o+r),t((u<<31|s/4294967296)>>>0,i,o+e)):(t(4503599627370496*(s=n*Math.pow(2,-(n=1024===(n=Math.floor(Math.log(n)/Math.LN2))?1023:n)))>>>0,i,o+r),t((u<<31|n+1023<<20|1048576*s&1048575)>>>0,i,o+e))}function g(t,r,e,n,i){return r=t(n,i+r),n=2*((t=t(n,i+e))>>31)+1,e=4294967296*(1048575&t)+r,2047==(i=t>>>20&2047)?e?NaN:1/0*n:0==i?5e-324*n*e:n*Math.pow(2,i-1075)*(e+4503599627370496)}function m(t,r,e){p[0]=t,r[e]=y[0],r[e+1]=y[1],r[e+2]=y[2],r[e+3]=y[3],r[e+4]=y[4],r[e+5]=y[5],r[e+6]=y[6],r[e+7]=y[7]}function w(t,r,e){p[0]=t,r[e]=y[7],r[e+1]=y[6],r[e+2]=y[5],r[e+3]=y[4],r[e+4]=y[3],r[e+5]=y[2],r[e+6]=y[1],r[e+7]=y[0]}function v(t,r){return y[0]=t[r],y[1]=t[r+1],y[2]=t[r+2],y[3]=t[r+3],y[4]=t[r+4],y[5]=t[r+5],y[6]=t[r+6],y[7]=t[r+7],p[0]}function A(t,r){return y[7]=t[r],y[6]=t[r+1],y[5]=t[r+2],y[4]=t[r+3],y[3]=t[r+4],y[2]=t[r+5],y[1]=t[r+6],y[0]=t[r+7],p[0]}return"undefined"!=typeof Float32Array?(a=new Float32Array([-0]),d=128===(c=new Uint8Array(a.buffer))[3],t.writeFloatLE=d?n:f,t.writeFloatBE=d?f:n,t.readFloatLE=d?h:l,t.readFloatBE=d?l:h):(t.writeFloatLE=r.bind(null,i),t.writeFloatBE=r.bind(null,o),t.readFloatLE=e.bind(null,s),t.readFloatBE=e.bind(null,u)),"undefined"!=typeof Float64Array?(p=new Float64Array([-0]),d=128===(y=new Uint8Array(p.buffer))[7],t.writeDoubleLE=d?m:w,t.writeDoubleBE=d?w:m,t.readDoubleLE=d?v:A,t.readDoubleBE=d?A:v):(t.writeDoubleLE=b.bind(null,i,0,4),t.writeDoubleBE=b.bind(null,o,4,0),t.readDoubleLE=g.bind(null,s,0,4),t.readDoubleBE=g.bind(null,u,4,0)),t}function i(t,r,e){r[e]=255&t,r[e+1]=t>>>8&255,r[e+2]=t>>>16&255,r[e+3]=t>>>24}function o(t,r,e){r[e]=t>>>24,r[e+1]=t>>>16&255,r[e+2]=t>>>8&255,r[e+3]=255&t}function s(t,r){return(t[r]|t[r+1]<<8|t[r+2]<<16|t[r+3]<<24)>>>0}function u(t,r){return(t[r]<<24|t[r+1]<<16|t[r+2]<<8|t[r+3])>>>0}r.exports=n(n)},{}],5:[function(t,n,i){function r(t){try{var n=eval("require")(t);if(n&&(n.length||Object.keys(n).length))return n}catch(t){}return null}n.exports=r},{}],6:[function(t,r,e){r.exports=function(t,r,e){var n=e||8192,i=n>>>1,o=null,s=n;return function(e){return e<1||i<e?t(e):(n<s+e&&(o=t(n),s=0),e=r.call(o,s,s+=e),7&s&&(s=1+(7|s)),e)}}},{}],7:[function(t,r,e){e.length=function(t){for(var r,e=0,n=0;n<t.length;++n)(r=t.charCodeAt(n))<128?e+=1:r<2048?e+=2:55296==(64512&r)&&56320==(64512&t.charCodeAt(n+1))?(++n,e+=4):e+=3;return e},e.read=function(t,r,e){if(e-r<1)return"";for(var n,i=null,o=[],s=0;r<e;)(n=t[r++])<128?o[s++]=n:191<n&&n<224?o[s++]=(31&n)<<6|63&t[r++]:239<n&&n<365?(n=((7&n)<<18|(63&t[r++])<<12|(63&t[r++])<<6|63&t[r++])-65536,o[s++]=55296+(n>>10),o[s++]=56320+(1023&n)):o[s++]=(15&n)<<12|(63&t[r++])<<6|63&t[r++],8191<s&&((i=i||[]).push(String.fromCharCode.apply(String,o)),s=0);return i?(s&&i.push(String.fromCharCode.apply(String,o.slice(0,s))),i.join("")):String.fromCharCode.apply(String,o.slice(0,s))},e.write=function(t,r,e){for(var n,i,o=e,s=0;s<t.length;++s)(n=t.charCodeAt(s))<128?r[e++]=n:(n<2048?r[e++]=n>>6|192:(55296==(64512&n)&&56320==(64512&(i=t.charCodeAt(s+1)))?(++s,r[e++]=(n=65536+((1023&n)<<10)+(1023&i))>>18|240,r[e++]=n>>12&63|128):r[e++]=n>>12|224,r[e++]=n>>6&63|128),r[e++]=63&n|128);return e-o}},{}],8:[function(t,r,e){var n=e;function i(){n.util.n(),n.Writer.n(n.BufferWriter),n.Reader.n(n.BufferReader)}n.build="minimal",n.Writer=t(16),n.BufferWriter=t(17),n.Reader=t(9),n.BufferReader=t(10),n.util=t(15),n.rpc=t(12),n.roots=t(11),n.configure=i,i()},{10:10,11:11,12:12,15:15,16:16,17:17,9:9}],9:[function(t,r,e){r.exports=f;var n,i=t(15),o=i.LongBits,s=i.utf8;function u(t,r){return RangeError("index out of range: "+t.pos+" + "+(r||1)+" > "+t.len)}function f(t){this.buf=t,this.pos=0,this.len=t.length}function h(){return i.Buffer?function(t){return(f.create=function(t){return i.Buffer.isBuffer(t)?new n(t):a(t)})(t)}:a}var l,a="undefined"!=typeof Uint8Array?function(t){if(t instanceof Uint8Array||Array.isArray(t))return new f(t);throw Error("illegal buffer")}:function(t){if(Array.isArray(t))return new f(t);throw Error("illegal buffer")};function c(){var t=new o(0,0),r=0;if(!(4<this.len-this.pos)){for(;r<3;++r){if(this.pos>=this.len)throw u(this);if(t.lo=(t.lo|(127&this.buf[this.pos])<<7*r)>>>0,this.buf[this.pos++]<128)return t}return t.lo=(t.lo|(127&this.buf[this.pos++])<<7*r)>>>0,t}for(;r<4;++r)if(t.lo=(t.lo|(127&this.buf[this.pos])<<7*r)>>>0,this.buf[this.pos++]<128)return t;if(t.lo=(t.lo|(127&this.buf[this.pos])<<28)>>>0,t.hi=(t.hi|(127&this.buf[this.pos])>>4)>>>0,this.buf[this.pos++]<128)return t;if(r=0,4<this.len-this.pos){for(;r<5;++r)if(t.hi=(t.hi|(127&this.buf[this.pos])<<7*r+3)>>>0,this.buf[this.pos++]<128)return t}else for(;r<5;++r){if(this.pos>=this.len)throw u(this);if(t.hi=(t.hi|(127&this.buf[this.pos])<<7*r+3)>>>0,this.buf[this.pos++]<128)return t}throw Error("invalid varint encoding")}function p(t,r){return(t[r-4]|t[r-3]<<8|t[r-2]<<16|t[r-1]<<24)>>>0}function y(){if(this.pos+8>this.len)throw u(this,8);return new o(p(this.buf,this.pos+=4),p(this.buf,this.pos+=4))}f.create=h(),f.prototype.i=i.Array.prototype.subarray||i.Array.prototype.slice,f.prototype.uint32=(l=4294967295,function(){if(l=(127&this.buf[this.pos])>>>0,this.buf[this.pos++]<128||(l=(l|(127&this.buf[this.pos])<<7)>>>0,this.buf[this.pos++]<128||(l=(l|(127&this.buf[this.pos])<<14)>>>0,this.buf[this.pos++]<128||(l=(l|(127&this.buf[this.pos])<<21)>>>0,this.buf[this.pos++]<128||(l=(l|(15&this.buf[this.pos])<<28)>>>0,this.buf[this.pos++]<128||!((this.pos+=5)>this.len))))))return l;throw this.pos=this.len,u(this,10)}),f.prototype.int32=function(){return 0|this.uint32()},f.prototype.sint32=function(){var t=this.uint32();return t>>>1^-(1&t)|0},f.prototype.bool=function(){return 0!==this.uint32()},f.prototype.fixed32=function(){if(this.pos+4>this.len)throw u(this,4);return p(this.buf,this.pos+=4)},f.prototype.sfixed32=function(){if(this.pos+4>this.len)throw u(this,4);return 0|p(this.buf,this.pos+=4)},f.prototype.float=function(){if(this.pos+4>this.len)throw u(this,4);var t=i.float.readFloatLE(this.buf,this.pos);return this.pos+=4,t},f.prototype.double=function(){if(this.pos+8>this.len)throw u(this,4);var t=i.float.readDoubleLE(this.buf,this.pos);return this.pos+=8,t},f.prototype.bytes=function(){var t=this.uint32(),r=this.pos,e=this.pos+t;if(e>this.len)throw u(this,t);return this.pos+=t,Array.isArray(this.buf)?this.buf.slice(r,e):r===e?new this.buf.constructor(0):this.i.call(this.buf,r,e)},f.prototype.string=function(){var t=this.bytes();return s.read(t,0,t.length)},f.prototype.skip=function(t){if("number"==typeof t){if(this.pos+t>this.len)throw u(this,t);this.pos+=t}else do{if(this.pos>=this.len)throw u(this)}while(128&this.buf[this.pos++]);return this},f.prototype.skipType=function(t){switch(t){case 0:this.skip();break;case 1:this.skip(8);break;case 2:this.skip(this.uint32());break;case 3:for(;4!=(t=7&this.uint32());)this.skipType(t);break;case 5:this.skip(4);break;default:throw Error("invalid wire type "+t+" at offset "+this.pos)}return this},f.n=function(t){n=t,f.create=h(),n.n();var r=i.Long?"toLong":"toNumber";i.merge(f.prototype,{int64:function(){return c.call(this)[r](!1)},uint64:function(){return c.call(this)[r](!0)},sint64:function(){return c.call(this).zzDecode()[r](!1)},fixed64:function(){return y.call(this)[r](!0)},sfixed64:function(){return y.call(this)[r](!1)}})}},{15:15}],10:[function(t,r,e){r.exports=o;var n=t(9),i=((o.prototype=Object.create(n.prototype)).constructor=o,t(15));function o(t){n.call(this,t)}o.n=function(){i.Buffer&&(o.prototype.i=i.Buffer.prototype.slice)},o.prototype.string=function(){var t=this.uint32();return this.buf.utf8Slice?this.buf.utf8Slice(this.pos,this.pos=Math.min(this.pos+t,this.len)):this.buf.toString("utf-8",this.pos,this.pos=Math.min(this.pos+t,this.len))},o.n()},{15:15,9:9}],11:[function(t,r,e){r.exports={}},{}],12:[function(t,r,e){e.Service=t(13)},{13:13}],13:[function(t,r,e){r.exports=i;var n=t(15);function i(t,r,e){if("function"!=typeof t)throw TypeError("rpcImpl must be a function");n.EventEmitter.call(this),this.rpcImpl=t,this.requestDelimited=!!r,this.responseDelimited=!!e}((i.prototype=Object.create(n.EventEmitter.prototype)).constructor=i).prototype.rpcCall=function t(r,e,i,o,s){if(!o)throw TypeError("request must be specified");var u=this;if(!s)return n.asPromise(t,u,r,e,i,o);if(!u.rpcImpl)return setTimeout((function(){s(Error("already ended"))}),0),d;try{return u.rpcImpl(r,e[u.requestDelimited?"encodeDelimited":"encode"](o).finish(),(function(t,e){if(t)return u.emit("error",t,r),s(t);if(null===e)return u.end(!0),d;if(!(e instanceof i))try{e=i[u.responseDelimited?"decodeDelimited":"decode"](e)}catch(t){return u.emit("error",t,r),s(t)}return u.emit("data",e,r),s(null,e)}))}catch(t){return u.emit("error",t,r),setTimeout((function(){s(t)}),0),d}},i.prototype.end=function(t){return this.rpcImpl&&(t||this.rpcImpl(null,null,null),this.rpcImpl=null,this.emit("end").off()),this}},{15:15}],14:[function(t,r,e){r.exports=i;var n=t(15);function i(t,r){this.lo=t>>>0,this.hi=r>>>0}var o=i.zero=new i(0,0),s=(o.toNumber=function(){return 0},o.zzEncode=o.zzDecode=function(){return this},o.length=function(){return 1},i.zeroHash="\0\0\0\0\0\0\0\0",i.fromNumber=function(t){var r,e;return 0===t?o:(e=(t=(r=t<0)?-t:t)>>>0,t=(t-e)/4294967296>>>0,r&&(t=~t>>>0,e=~e>>>0,4294967295<++e&&(e=0,4294967295<++t&&(t=0))),new i(e,t))},i.from=function(t){if("number"==typeof t)return i.fromNumber(t);if(n.isString(t)){if(!n.Long)return i.fromNumber(parseInt(t,10));t=n.Long.fromString(t)}return t.low||t.high?new i(t.low>>>0,t.high>>>0):o},i.prototype.toNumber=function(t){var r;return!t&&this.hi>>>31?(t=1+~this.lo>>>0,r=~this.hi>>>0,-(t+4294967296*(r=t?r:r+1>>>0))):this.lo+4294967296*this.hi},i.prototype.toLong=function(t){return n.Long?new n.Long(0|this.lo,0|this.hi,!!t):{low:0|this.lo,high:0|this.hi,unsigned:!!t}},String.prototype.charCodeAt);i.fromHash=function(t){return"\0\0\0\0\0\0\0\0"===t?o:new i((s.call(t,0)|s.call(t,1)<<8|s.call(t,2)<<16|s.call(t,3)<<24)>>>0,(s.call(t,4)|s.call(t,5)<<8|s.call(t,6)<<16|s.call(t,7)<<24)>>>0)},i.prototype.toHash=function(){return String.fromCharCode(255&this.lo,this.lo>>>8&255,this.lo>>>16&255,this.lo>>>24,255&this.hi,this.hi>>>8&255,this.hi>>>16&255,this.hi>>>24)},i.prototype.zzEncode=function(){var t=this.hi>>31;return this.hi=((this.hi<<1|this.lo>>>31)^t)>>>0,this.lo=(this.lo<<1^t)>>>0,this},i.prototype.zzDecode=function(){var t=-(1&this.lo);return this.lo=((this.lo>>>1|this.hi<<31)^t)>>>0,this.hi=(this.hi>>>1^t)>>>0,this},i.prototype.length=function(){var t=this.lo,r=(this.lo>>>28|this.hi<<4)>>>0,e=this.hi>>>24;return 0==e?0==r?t<16384?t<128?1:2:t<2097152?3:4:r<16384?r<128?5:6:r<2097152?7:8:e<128?9:10}},{15:15}],15:[function(t,r,e){var n=e;function i(t,r,e){for(var n=Object.keys(r),i=0;i<n.length;++i)t[n[i]]!==d&&e||(t[n[i]]=r[n[i]]);return t}function o(t){function r(t,e){if(!(this instanceof r))return new r(t,e);Object.defineProperty(this,"message",{get:function(){return t}}),Error.captureStackTrace?Error.captureStackTrace(this,r):Object.defineProperty(this,"stack",{value:Error().stack||""}),e&&i(this,e)}return r.prototype=Object.create(Error.prototype,{constructor:{value:r,writable:!0,enumerable:!1,configurable:!0},name:{get:()=>t,set:d,enumerable:!1,configurable:!0},toString:{value(){return this.name+": "+this.message},writable:!0,enumerable:!1,configurable:!0}}),r}n.asPromise=t(1),n.base64=t(2),n.EventEmitter=t(3),n.float=t(4),n.inquire=t(5),n.utf8=t(7),n.pool=t(6),n.LongBits=t(14),n.isNode=!!(void 0!==commonjsGlobal&&commonjsGlobal&&commonjsGlobal.process&&commonjsGlobal.process.versions&&commonjsGlobal.process.versions.node),n.global=n.isNode&&commonjsGlobal||"undefined"!=typeof window&&window||"undefined"!=typeof self&&self||this,n.emptyArray=Object.freeze?Object.freeze([]):[],n.emptyObject=Object.freeze?Object.freeze({}):{},n.isInteger=Number.isInteger||function(t){return"number"==typeof t&&isFinite(t)&&Math.floor(t)===t},n.isString=function(t){return"string"==typeof t||t instanceof String},n.isObject=function(t){return t&&"object"==typeof t},n.isset=n.isSet=function(t,r){var e=t[r];return null!=e&&t.hasOwnProperty(r)&&("object"!=typeof e||0<(Array.isArray(e)?e:Object.keys(e)).length)},n.Buffer=function(){try{var t=n.inquire("buffer").Buffer;return t.prototype.utf8Write?t:null}catch(t){return null}}(),n.r=null,n.u=null,n.newBuffer=function(t){return"number"==typeof t?n.Buffer?n.u(t):new n.Array(t):n.Buffer?n.r(t):"undefined"==typeof Uint8Array?t:new Uint8Array(t)},n.Array="undefined"!=typeof Uint8Array?Uint8Array:Array,n.Long=n.global.dcodeIO&&n.global.dcodeIO.Long||n.global.Long||n.inquire("long"),n.key2Re=/^true|false|0|1$/,n.key32Re=/^-?(?:0|[1-9][0-9]*)$/,n.key64Re=/^(?:[\\x00-\\xff]{8}|-?(?:0|[1-9][0-9]*))$/,n.longToHash=function(t){return t?n.LongBits.from(t).toHash():n.LongBits.zeroHash},n.longFromHash=function(t,r){return t=n.LongBits.fromHash(t),n.Long?n.Long.fromBits(t.lo,t.hi,r):t.toNumber(!!r)},n.merge=i,n.lcFirst=function(t){return(t[0]||"").toLowerCase()+t.substring(1)},n.newError=o,n.ProtocolError=o("ProtocolError"),n.oneOfGetter=function(t){for(var r={},e=0;e<t.length;++e)r[t[e]]=1;return function(){for(var t=Object.keys(this),e=t.length-1;-1<e;--e)if(1===r[t[e]]&&this[t[e]]!==d&&null!==this[t[e]])return t[e]}},n.oneOfSetter=function(t){return function(r){for(var e=0;e<t.length;++e)t[e]!==r&&delete this[t[e]]}},n.toJSONOptions={longs:String,enums:String,bytes:String,json:!0},n.n=function(){var t=n.Buffer;t?(n.r=t.from!==Uint8Array.from&&t.from||function(r,e){return new t(r,e)},n.u=t.allocUnsafe||function(r){return new t(r)}):n.r=n.u=null}},{1:1,14:14,2:2,3:3,4:4,5:5,6:6,7:7}],16:[function(t,r,e){r.exports=a;var n,i=t(15),o=i.LongBits,s=i.base64,u=i.utf8;function f(t,r,e){this.fn=t,this.len=r,this.next=d,this.val=e}function h(){}function l(t){this.head=t.head,this.tail=t.tail,this.len=t.len,this.next=t.states}function a(){this.len=0,this.head=new f(h,0,0),this.tail=this.head,this.states=null}function c(){return i.Buffer?function(){return(a.create=function(){return new n})()}:function(){return new a}}function p(t,r,e){r[e]=255&t}function y(t,r){this.len=t,this.next=d,this.val=r}function b(t,r,e){for(;t.hi;)r[e++]=127&t.lo|128,t.lo=(t.lo>>>7|t.hi<<25)>>>0,t.hi>>>=7;for(;127<t.lo;)r[e++]=127&t.lo|128,t.lo=t.lo>>>7;r[e++]=t.lo}function g(t,r,e){r[e]=255&t,r[e+1]=t>>>8&255,r[e+2]=t>>>16&255,r[e+3]=t>>>24}a.create=c(),a.alloc=function(t){return new i.Array(t)},i.Array!==Array&&(a.alloc=i.pool(a.alloc,i.Array.prototype.subarray)),a.prototype.e=function(t,r,e){return this.tail=this.tail.next=new f(t,r,e),this.len+=r,this},(y.prototype=Object.create(f.prototype)).fn=function(t,r,e){for(;127<t;)r[e++]=127&t|128,t>>>=7;r[e]=t},a.prototype.uint32=function(t){return this.len+=(this.tail=this.tail.next=new y((t>>>=0)<128?1:t<16384?2:t<2097152?3:t<268435456?4:5,t)).len,this},a.prototype.int32=function(t){return t<0?this.e(b,10,o.fromNumber(t)):this.uint32(t)},a.prototype.sint32=function(t){return this.uint32((t<<1^t>>31)>>>0)},a.prototype.int64=a.prototype.uint64=function(t){return t=o.from(t),this.e(b,t.length(),t)},a.prototype.sint64=function(t){return t=o.from(t).zzEncode(),this.e(b,t.length(),t)},a.prototype.bool=function(t){return this.e(p,1,t?1:0)},a.prototype.sfixed32=a.prototype.fixed32=function(t){return this.e(g,4,t>>>0)},a.prototype.sfixed64=a.prototype.fixed64=function(t){return t=o.from(t),this.e(g,4,t.lo).e(g,4,t.hi)},a.prototype.float=function(t){return this.e(i.float.writeFloatLE,4,t)},a.prototype.double=function(t){return this.e(i.float.writeDoubleLE,8,t)};var m=i.Array.prototype.set?function(t,r,e){r.set(t,e)}:function(t,r,e){for(var n=0;n<t.length;++n)r[e+n]=t[n]};a.prototype.bytes=function(t){var r,e=t.length>>>0;return e?(i.isString(t)&&(r=a.alloc(e=s.length(t)),s.decode(t,r,0),t=r),this.uint32(e).e(m,e,t)):this.e(p,1,0)},a.prototype.string=function(t){var r=u.length(t);return r?this.uint32(r).e(u.write,r,t):this.e(p,1,0)},a.prototype.fork=function(){return this.states=new l(this),this.head=this.tail=new f(h,0,0),this.len=0,this},a.prototype.reset=function(){return this.states?(this.head=this.states.head,this.tail=this.states.tail,this.len=this.states.len,this.states=this.states.next):(this.head=this.tail=new f(h,0,0),this.len=0),this},a.prototype.ldelim=function(){var t=this.head,r=this.tail,e=this.len;return this.reset().uint32(e),e&&(this.tail.next=t.next,this.tail=r,this.len+=e),this},a.prototype.finish=function(){for(var t=this.head.next,r=this.constructor.alloc(this.len),e=0;t;)t.fn(t.val,r,e),e+=t.len,t=t.next;return r},a.n=function(t){n=t,a.create=c(),n.n()}},{15:15}],17:[function(t,r,e){r.exports=o;var n=t(16),i=((o.prototype=Object.create(n.prototype)).constructor=o,t(15));function o(){n.call(this)}function s(t,r,e){t.length<40?i.utf8.write(t,r,e):r.utf8Write?r.utf8Write(t,e):r.write(t,e)}o.n=function(){o.alloc=i.u,o.writeBytesBuffer=i.Buffer&&i.Buffer.prototype instanceof Uint8Array&&"set"===i.Buffer.prototype.set.name?function(t,r,e){r.set(t,e)}:function(t,r,e){if(t.copy)t.copy(r,e,0,t.length);else for(var n=0;n<t.length;)r[e++]=t[n++]}},o.prototype.bytes=function(t){var r=(t=i.isString(t)?i.r(t,"base64"):t).length>>>0;return this.uint32(r),r&&this.e(o.writeBytesBuffer,r,t),this},o.prototype.string=function(t){var r=i.Buffer.byteLength(t);return this.uint32(r),r&&this.e(s,r,t),this},o.n()},{15:15,16:16}]},u={},n=function t(e){var n=u[e];return n||r[e][0].call(n=u[e]={exports:{}},t,n,n.exports),n.exports}(8),n.util.global.protobuf=n,module&&module.exports&&(module.exports=n)}()})(protobuf_min$1);var protobuf_min=protobuf_min$1.exports;export{protobuf_min as default};