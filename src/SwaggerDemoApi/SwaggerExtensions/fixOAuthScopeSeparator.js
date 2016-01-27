// Manually set the OAuth scope separator to a space because current version of Swashbuckle
// doesn't allow us to set it. IdentityServer3 requires scopes to be space delimited
// This can be removed once this commit is pushed to nuget: 
// https://github.com/domaindrivendev/Swashbuckle/commit/5ff309e9752f32256ad08d1c538cc858de242d90
window.swashbuckleConfig.oAuth2ScopeSeperator = " ";
scopeSeparator = " ";